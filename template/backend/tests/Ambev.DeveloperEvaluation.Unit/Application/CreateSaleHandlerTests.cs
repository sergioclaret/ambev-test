﻿using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _saleRepository = Substitute.For<ISaleRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateSaleHandler(_saleRepository, _mapper);
        }

        /// <summary>
        /// Tests that a valid sale creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            var command = CreateSaleHandlerTestData.GenerateValidCommand();
            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                Number = command.Number,
                Date = command.Date,
                CustomerId = command.CustomerId,
                CustomerName = command.CustomerName,
                BranchId = command.BranchId,
                BranchName = command.BranchName,
                Products = command.Products.ConvertAll(p => new Product
                {
                    Name = p.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity
                })};

            var result = new CreateSaleResult
            {
                Id = sale.Id
            };

            _mapper.Map<Sale>(command).Returns(sale);
            _mapper.Map<CreateSaleResult>(sale).Returns(result);

            _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
                .Returns(sale);

            // When
            var createSaleResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createSaleResult.Should().NotBeNull();
            createSaleResult.Id.Should().Be(sale.Id);

            await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
        }
    }
}
