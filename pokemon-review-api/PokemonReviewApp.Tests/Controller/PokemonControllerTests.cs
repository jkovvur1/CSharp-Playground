﻿using System;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Tests.Controller
{
	public class PokemonControllerTests
	{
		private readonly IPokemonRepository _pokemonRepository;
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

		public PokemonControllerTests()
		{
            _pokemonRepository = A.Fake<IPokemonRepository>();
			_reviewRepository = A.Fake<IReviewRepository>();
			_mapper = A.Fake<IMapper>();

		}

		[Fact]
		public void PokemonController_GetPokemons_ReturnOK()
		{
			// Arrange
			var pokemons = A.Fake<ICollection<PokemonDto>>();
			var pokemonList = A.Fake<List<PokemonDto>>();
			A.CallTo(() => _mapper.Map<List<PokemonDto>>(pokemons)).Returns(pokemonList);
			var controller = new PokemonController(_pokemonRepository, _reviewRepository, _mapper);

			//Act
			var result = controller.GetPokemons();

			//Assert
			result.Should().NotBeNull();
			result.Should().BeOfType(typeof(OkObjectResult));
		}



		[Fact]
		public void PokemonController_CreatePokemon_ReturnsOK()
		{
			//Arrange
			int ownerId = 1;
			int catId = 2;
			var pokemon = A.Fake<Pokemon>();
			var pokemonCreate = A.Fake<PokemonDto>();
			var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonList = A.Fake<List<PokemonDto>>();
			A.CallTo(() => _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate)).Returns(pokemon);

			A.CallTo(() => _mapper.Map<Pokemon>(pokemonCreate)).Returns(pokemon);
			A.CallTo(() => _pokemonRepository.CreatePokemon(ownerId, catId, pokemon)).Returns(true);
			var controller = new PokemonController(_pokemonRepository, _reviewRepository, _mapper);

			//Act
			var result = controller.CreatePokemon(ownerId, catId, pokemonCreate);

			//Assert
			result.Should().NotBeNull();
		}
	}
}

