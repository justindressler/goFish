﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goFish
{
	class Deck
	{
		private List<Card> cards;
		private Random random = new Random();

		public Deck() {
			cards = new List<Card>();
			for (int suit = 0; suit <=3; suit++) {
				for (int value = 1; value <=13; value++) {
					cards.Add(new Card((Suits)suit, (Values)value));
				}
			}
		}
		public Deck(IEnumerable<Card> initialCards) {
			cards = new List<Card>(initialCards);
		}

		public int Count { get { return cards.Count; } }

		public void Add(Card cardToAdd) {
			cards.Add(cardToAdd);
		}

		public Card Deal(int index) {
			Card CardToDeal = cards[index];
			cards.RemoveAt(index);
			return CardToDeal;
		}
		public Card Deal() {
			return Deal(0);
		}

		public void Shuffle() {
			//this method shuffles the cards by rearranging them in a random order
			List<Card> NewCards = new List<Card>();
			while (cards.Count > 0) {
				int CardToMove = random.Next(cards.Count);
				NewCards.Add(cards[CardToMove]);
				cards.RemoveAt(CardToMove);
			}
			cards = NewCards;
		}

		public IEnumerable<string> GetCardNames() {
			//this method return a string array that contains each card's name
			string[] CardNames = new string[cards.Count];
			for(int i = 0; i < cards.Count; i++) {
				CardNames[i] = cards[i].Name;
			}

			return CardNames;
		}

		public void Sort() {
			cards.Sort(new CardComparer_bySuit());
		}
		public void SortByValue() {
			cards.Sort(new CardComparer_byValue());
		}

		public Card Peek(int cardNumber) {
			return cards[cardNumber];
		}

		public bool ContainsValue(Values value) {
			foreach(Card card in cards) {
				if (card.Value == value)
					return true;				
			}
			return false;
		}

		public bool HasBook(Values value) {
			int NumberOfCards = 0;
			foreach(Card card in cards) {
				if(card.Value == value) {
					NumberOfCards++;
				}
			}
			if (NumberOfCards == 4)
				return true;
			else
				return false;
		}
	}
}