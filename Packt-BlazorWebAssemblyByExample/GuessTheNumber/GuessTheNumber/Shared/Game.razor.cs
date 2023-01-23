using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using GuessTheNumber;

namespace GuessTheNumber.Shared
{
    public partial class Game
    {
        [Parameter]
        public int? Digits { get; set; }

        private int _digitCount = 4;
        private string _answer = string.Empty;
        private string _guess = string.Empty;
        private List<Row> _guesses = new();
        private bool _winner = false;

        protected override void OnParametersSet()
        {
            if (Digits.HasValue)
                _digitCount = (int)Digits;

            CalculateAnswer();
        }

        private void CalculateAnswer()
        {
            StringBuilder answerText = new StringBuilder();

            for (int i = 0; i < _digitCount; i++)
            {
                int nextDigit = new Random().Next(0, 10);
                answerText.Append(nextDigit);
            }

            _answer = answerText.ToString();

            logger.LogInformation($"The answer is {_answer}");
        }

        private void GuessAnswer()
        {
            var currentGuess = new Row()
            {
                Guess = _guess, 
                Matches = new string[_digitCount]
            };

            for (int i = 0; i < _digitCount; i++)
            {
                if (_answer[i] == _guess[i])
                    currentGuess.Matches[i] = "match-pos";
                else
                {
                    if (_answer.Contains(_guess[i]))
                    {
                        currentGuess.Matches[i] = "match-val";
                    }
                }
            }

            _guesses.Add(currentGuess);

            if (_guess == _answer)
                _winner = true;

            _guess = string.Empty;

            logger.LogInformation(JsonSerializer.Serialize(_guesses));
        }

        private void PlayAgain()
        {
            _winner = false;

            _guesses = new();

            CalculateAnswer();
        }

        private void RestartGame(ChangeEventArgs e)
        {
            _digitCount = Convert.ToInt16(e.Value);

            PlayAgain();
        }

        public class Row
        {
            public string Guess { get; set; } = string.Empty;
            public string[] Matches { get; set; } = default !;
        }
    }
}