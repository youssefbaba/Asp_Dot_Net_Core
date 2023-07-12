﻿using Assignement_21.Controllers;
using Assignement_21.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ServiceContracts.DTO;

namespace Assignement_21.Filters.ActionFilter
{
    public class CreateOrderActionFilter : IAsyncActionFilter
    {
        // Fields
        private readonly ILogger<CreateOrderActionFilter> _logger;

        // Constructors
        public CreateOrderActionFilter(ILogger<CreateOrderActionFilter> logger)
        {
            _logger = logger;
        }

        // Methods
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // To Do: before logic here
            _logger.LogInformation("before logic of {FilterName}.{MethodName} method", nameof(CreateOrderActionFilter), nameof(OnActionExecutionAsync));
            if (context.Controller is TradeController tradeController)
            {
                var orderRequest = context.ActionArguments["orderRequest"] as IOrderRequest;
                if (orderRequest != null)
                {
                    orderRequest.DateAndTimeOfOrder = DateTime.Now;

                    // Revalidate
                    tradeController.ModelState.Clear();
                    tradeController.TryValidateModel(orderRequest);

                    // Model Validation
                    if (!tradeController.ModelState.IsValid)
                    {
                        List<string> errors = tradeController.ModelState.Values.SelectMany(value => value.Errors)
                                            .Select(error => error.ErrorMessage)
                                            .ToList();
                        tradeController.ViewBag.Errors = errors;

                        StockTrade stockTrade = new StockTrade()
                        {
                            StockSymbol = orderRequest.StockSymbol,
                            StockName = orderRequest.StockName,
                            Price = orderRequest.Price,
                            Quantity = orderRequest.Quantity
                        };

                        context.Result = tradeController.View(nameof(Index), stockTrade);
                    }
                    else
                    {
                        await next();
                    }
                }
                else
                {
                    await next();
                }
            }
            else
            {
                await next();
            }
        }
    }
}
