﻿using Agathas.Storefront.Infrastructure;
using Agathas.Storefront.Sales.Api.Commands;
using Agathas.Storefront.Shopping.Baskets;
using Agathas.Storefront.Shopping.Model.Baskets;

namespace Agathas.Storefront.Application.Handlers
{
    public class RemoveOfferFromBasketCommandHandler : ICommandHandler<RemoveOfferFromBasketCommand>
    {
        private readonly IBasketRepository _basket_repository;
        private readonly IBasketPricingService _basketPricingService;

        public RemoveOfferFromBasketCommandHandler(IBasketRepository basket_repository,
                                                   IBasketPricingService basketPricingService)
        {
            _basket_repository = basket_repository;
            _basketPricingService = basketPricingService;
        }

        public void action(RemoveOfferFromBasketCommand business_request)
        {
            var basket = _basket_repository.find_by(business_request.basket_id);

            basket.remove_coupon(business_request.coupon_code, _basketPricingService);

            _basket_repository.save(basket);
        }
    }
}