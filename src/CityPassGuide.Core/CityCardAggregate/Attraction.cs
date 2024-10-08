﻿using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityCardAggregate;

public class Attraction(string name, int cityId, decimal price) : EntityBase
{
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public int CityId { get; private set; } = Guard.Against.NegativeOrZero(cityId);
  public decimal Price { get; private set; } = Guard.Against.Negative(price);

  private readonly List<CityCard> _cityCards = [];
  public IEnumerable<CityCard> CityCards => _cityCards.AsReadOnly();
}
