using System.Collections.Generic;
using System.Linq;

namespace PVCodeChallenge.BusinessLogic
{
    public class BLFactory
    {

        #region BARE MINIMUM

        //When "Register" is selected,
        // Get list of numbers which are multiples of 3 ALONE and set their value as 'Register'
        // Get list of numbers which are multiples of 5 ALONE and set their value as 'Patient'
        // Get list of numbers which are multiples of 3 and 5, set their value as 'Registe'&'Patient'
        // Get rest of the numbers
        // Finally Join all the lists using LINQ "Concat"
        public Dictionary<int, string> GetNumbersForRegister(int minNum, int maxNum)
        {

            var allnumbers = Enumerable.Range(minNum, maxNum);

            var multiplesof3 = allnumbers
                                .Where(x => x % 3 == 0)
                                .Where(x => x % 5 != 0)
                                .ToDictionary(key => key, value => "'Register'");
            var multiplesof5 = allnumbers
                                .Where(x => x % 5 == 0)
                                .Where(x => x % 3 != 0)
                                .ToDictionary(key => key, value => "'Patient'");
            var multiplesofboth = allnumbers
                                    .Where(x => x % 3 == 0)
                                    .Where(x => x % 5 == 0)
                                    .ToDictionary(key => key, value => "'Register'&'Patient'");
            var multiplesofnone = allnumbers
                                    .Where(x => x % 3 != 0)
                                    .Where(x => x % 5 != 0)
                                    .ToDictionary(key => key, value => value.ToString());

            Dictionary<int, string> sortedresults = ((multiplesof3.Concat(multiplesof5)).Concat(multiplesofboth)).Concat(multiplesofnone)
                                                .OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, y => y.Value);

            return sortedresults;
        }

        //When "Register" is selected,
        // Get list of numbers which are multiples of 2 ALONE and set their value as 'Diagnose'
        // Get list of numbers which are multiples of 7 ALONE and set their value as 'Patient'
        // Get list of numbers which are multiples of 2 and 7, set their value as 'Diagnose'&'Patient'
        // Get rest of the numbers
        // Finally Join all the lists using LINQ "Concat"
        public Dictionary<int, string> GetNumbersForDiagnose(int minNum, int maxNum)
        {
            var allnumbers = Enumerable.Range(minNum, maxNum);

            var multiplesof2 = allnumbers
                                .Where(x => x % 2 == 0)
                                .Where(x => x % 7 != 0)
                                .ToDictionary(key => key, value => "'Diagnose'");
            var multiplesof7 = allnumbers
                                .Where(x => x % 7 == 0)
                                .Where(x => x % 2 != 0)
                                .ToDictionary(key => key, value => "'Patient'");
            var multiplesofboth = allnumbers
                                    .Where(x => x % 2 == 0)
                                    .Where(x => x % 7 == 0)
                                    .ToDictionary(key => key, value => "'Diagnose'&'Patient'");
            var multiplesofnone = allnumbers
                                    .Where(x => x % 2 != 0)
                                    .Where(x => x % 7 != 0)
                                    .ToDictionary(key => key, value => value.ToString());

            Dictionary<int, string> sortedresults = ((multiplesof2.Concat(multiplesof7)).Concat(multiplesofboth)).Concat(multiplesofnone)
                                                .OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, y => y.Value);

            return sortedresults;
        }

        #endregion


    }


    /*----------- IMPROVED MEMORY --------------------*/
    public static class BLFactoryIM
    {
        #region IMPROVED MEMORY

        public static Dictionary<int, string> GetNumbersForRegisterIM(int minNum, int maxNum)
        {

            var allnumbers = Enumerable.Range(minNum, maxNum);

            Dictionary<int, string> sortedresults = (allnumbers
                                                        .Where(x => x % 3 == 0)
                                                        .Where(x => x % 7 != 0)
                                                        .ToDictionary(key => key, value => "'Register'"))
                                                    .Union
                                                        (allnumbers
                                                        .Where(x => x % 7 == 0)
                                                        .Where(x => x % 3 != 0)
                                                        .ToDictionary(key => key, value => "'Patient'")
                                                    )
                                                    .Union
                                                    (
                                                        allnumbers
                                                        .Where(x => x % 3 == 0)
                                                        .Where(x => x % 7 == 0)
                                                        .ToDictionary(key => key, value => "'Register'&'Patient'")
                                                    )
                                                    .Union
                                                    (
                                                        allnumbers
                                                        .Where(x => x % 3 != 0)
                                                        .Where(x => x % 7 != 0)
                                                        .ToDictionary(key => key, value => value.ToString())
                                                    )
                                                .OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, y => y.Value);

            return sortedresults;
        }

        public static Dictionary<int, string> GetNumbersForDiagnoseIM(int minNum, int maxNum)
        {
            var allnumbers = Enumerable.Range(minNum, maxNum);

            Dictionary<int, string> sortedresults = (allnumbers
                                                        .Where(x => x % 2 == 0)
                                                        .Where(x => x % 7 != 0)
                                                        .ToDictionary(key => key, value => "'Diagnose'"))
                                                    .Union
                                                        (allnumbers
                                                        .Where(x => x % 7 == 0)
                                                        .Where(x => x % 2 != 0)
                                                        .ToDictionary(key => key, value => "'Patient'")
                                                    )
                                                    .Union
                                                    (
                                                        allnumbers
                                                        .Where(x => x % 2 == 0)
                                                        .Where(x => x % 7 == 0)
                                                        .ToDictionary(key => key, value => "'Diagnose'&'Patient'")
                                                    )
                                                    .Union
                                                    (
                                                        allnumbers
                                                        .Where(x => x % 2 != 0)
                                                        .Where(x => x % 7 != 0)
                                                        .ToDictionary(key => key, value => value.ToString())
                                                    )
                                                .OrderBy(x => x.Key)
                                                .ToDictionary(x => x.Key, y => y.Value);

            return sortedresults;
        }

        #endregion
    }
}
