using BudgetControl.Application.Categories.Contracts;
using BudgetControl.Domain.LedgerAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BudgetControl.Application.Categories.Commands;

public record CategoryCreateCommand(string Name,
                                          float Goal,
                                          string Color,
                                          string? LedgerId) : IRequest<ErrorOr<CategoryResult>>;