using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

using Wajba.Models.OfferDomain;

using Wajba.OffersContract;
using Wajba.Services.ImageService;

namespace Wajba.OfferService
{
    [RemoteService(false)]
    public class OfferAppService : ApplicationService
    {
        private readonly IRepository<Offer, int> _offerRepository;
        private readonly IImageService _fileUploadService;
       
      

        public OfferAppService( IRepository<Offer, int> offerRepository, IImageService imageService)
        {
            _offerRepository = offerRepository;
            _fileUploadService = imageService;
        }

        public async Task<OfferDto> CreateAsync(CreateUpdateOfferDto input)
        {
            var offer = ObjectMapper.Map<CreateUpdateOfferDto, Offer>(input);

            // Upload image
            if (input.Image != null)
            {
                offer.ImageUrl = await _fileUploadService.UploadAsync(input.Image);
            }

            var createdOffer = await _offerRepository.InsertAsync(offer);
            return ObjectMapper.Map<Offer, OfferDto>(createdOffer);
        }

        public async Task<OfferDto> UpdateAsync(int id, CreateUpdateOfferDto input)
        {
            var offer = await _offerRepository.GetAsync(id);

            ObjectMapper.Map(input, offer);

            // Handle image update
            if (input.Image != null)
            {
                offer.ImageUrl = await _fileUploadService.UploadAsync(input.Image);
            }

            var updatedOffer = await _offerRepository.UpdateAsync(offer);
            return ObjectMapper.Map<Offer, OfferDto>(updatedOffer);
        }

        public async Task<OfferDto> GetAsync(int id)
        {
            var offer = await _offerRepository.GetAsync(id);
            return ObjectMapper.Map<Offer, OfferDto>(offer);
        }

        public async Task<PagedResultDto<OfferDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var offers = await _offerRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            var totalCount = await _offerRepository.GetCountAsync();

            return new PagedResultDto<OfferDto>(
                totalCount,
                ObjectMapper.Map<List<Offer>, List<OfferDto>>(offers)
            );
        }

        public async Task DeleteAsync(int id)
        {
            await _offerRepository.DeleteAsync(id);
        }
    }
}
