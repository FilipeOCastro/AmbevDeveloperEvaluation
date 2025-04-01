﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart
{
    public class DeleteCartValidator : AbstractValidator<DeleteCartCommand>
    {
        public DeleteCartValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID do carrinho é obrigatório");
        }
    }
}
