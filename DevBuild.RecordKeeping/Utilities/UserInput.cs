using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.Utilities
{
    public enum YesNoAnswer { No = 0, Yes = 1, AnswerNotGiven = 2, } //for convention's sake, let's make sure Yes = 1 and No = 0;
    
    class UserInput
    {
        /// <summary>
        /// This function prompts the user to type "y", "yes", "n", or "no" to provide a yes-or-no answer. Function stays in a loop until 
        /// user enters something we recognize as a yes or no answer.
        /// </summary>
        /// <returns>A yes-or-no answer enum set to Yes, No, or Answer Not Given. </returns>
        public static YesNoAnswer GetYesOrNoAnswer(string questionPrompt)
        {
            string userResponse = "";

            while ( userResponse != "y" && userResponse != "yes" && 
                    userResponse != "n" && userResponse != "no")
            {
                Console.Write(questionPrompt);
                userResponse = Console.ReadLine().Trim().ToLower();
            }
            switch (userResponse)
            {
                case "y":
                case "yes": return YesNoAnswer.Yes;
                case "n":
                case "no":  return YesNoAnswer.No;
                default:    return YesNoAnswer.AnswerNotGiven;
            }
        }

        public static string PromptUntilValidEntry(string message, params InformationType[] inputValidationFilters) {
            string response = "";
        LoopStart:
            Console.Write(message);
            while (String.IsNullOrEmpty(response)) {
                response = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(response)) {
                    Console.Write(message);
                    continue;
                }
                foreach (InformationType infoType in inputValidationFilters) {
                    if (!Validation.ValidateInfo(infoType, response)) {
                        response = "";
                        goto LoopStart;
                    }
                }
            }
            return response;
        }

        public static void PromptUntilValidEntry(string message, out string response, params InformationType[] inputValidationFilters)
        {
            response = "";
            LoopStart:
            Console.Write(message);
            while (String.IsNullOrEmpty(response))
            {
                response = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(response))
                {
                    Console.Write(message);
                    continue;
                }
                foreach (InformationType infoType in inputValidationFilters)
                {
                    if (!Validation.ValidateInfo(infoType, response))
                    {
                        response = "";
                        goto LoopStart;
                    }
                }
            }
            return;
        }


        /// <summary>
        /// This method allows for selection from a displayed menu, assuming the first menu option will always be 1"
        /// </summary>
        /// <param name="numberOfOptions"></param>
        /// <returns></returns>
        [Obsolete("This method is here for legacy purposes. Please use the more versatile SelectNumberBetween method in the future.")]
        public static uint SelectMenuOption(int numberOfOptions) {
            uint userSelection = (uint)SelectNumberBetween(1, numberOfOptions);
            return userSelection;
        }

        /// <summary>
        /// Allows user to obtain a number between a given minimum and a given maximum
        /// </summary>
        /// <param name="minimum">The minimum number allowed to be selected, inclusive.</param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static double SelectNumberBetween(int minimum, int maximum) {
            double userSelection = 0.0f;
            string userEntry = "";
            while (!double.TryParse(userEntry, out userSelection) ||
                    userSelection < minimum ||
                    userSelection > maximum) {
                PromptUntilValidEntry($"Please enter a selection, {minimum}-{maximum}: ", out userEntry, InformationType.Numeric);
            }
            return userSelection;
        }
    }


}
