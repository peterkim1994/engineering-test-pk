using System;
using System.Collegctions.Generic;
using System.Linq;

/*
 * Notes:
 * There are quite a bit a few issues in this code. In in a real pull request at work, I would actually opt to jump on a call to go discuss everything nicely and informatively
 * rather than spamming a bunch of comments pointing out every single issue off the bat. After the call I would comment/summerise the key action points in the PR for reference.
 * For the purpose of the exercise I still added comments for everything a tone as I typically use when the PR was not discussed over a call.
 *
 * Assumptions:
 * 1) A grad/junior, or someone new to C# submitted this PR.
 * 2) Editor config file exists for project/repo.
 * 3) Namespace matches directory structure
 */

namespace Utility.Valocity.ProfileHelper
{
    /*
     * Comment:
     * I would opt to move this class to a more appropiate directory with the other models since its not really a helper.
     * Also since this class seems like its for an individual, Person would probably be a more suitable class name.
     */
    public class People
    { 
        
     /*
      * Comment:
      * Assuming you want the the exact utc date 16 years ago, since its a static field, it could be outdated once if it ticked over to the next day.
      */
     private static readonly DateTimeOffset Under16 = x.UtcNow.AddYears(-15);
     
     /*
      * Comment:
      * This could be made readonly unless there are valid scenarios where it can change
      */
     public string Name { get; private set; }
     public DateTimeOffset DOB { get; private set; }
     public People(string name) : this(name, Under16.Date) { } 
     /*
      * Comment:
      * Is there a specific reason why the DOB always defaults to 16 years ago for this constructor overload? If there is a
      * good reason, it would be worth adding some comment docs stating that as its not obvious.
      */
     public People(string name, DateTime dob) {
         Name = name;
         DOB = dob;
     }} 
    /*
     * Comment:
     * Were you meant have dob be DateTimeOffset instead of Datetime?
     * Btw it's convention to have curly braces to start on a new line in C#. I'd reccomend to update the setting's on your IDE to auto format (based off the editor config file)
     * any changed code on save, that way you can just set and forget :)
     */
    
    public class BirthingUnit
    /*
     * Comment:
     * It's typically best to have one class per file in C# unless theres a good reason. Also the class name doesnt really seem appropiate for what the class does.
     * Some unit tests for this class would also be good. 
     */
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        /*
         * Comment: Think you forgot to update the comment doc for this field
         */
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        /*
         * Comment:
         * Don't know if it was intentional but the summary is just the method name and a description of what the method.
         * The name of the param also doesnt match the input and is missing a description. 
         */
        public List<People> GetPeople(int i)
        {
            /*
             * Comment:
             * I suggest extracting out this loop to it's own function, it doesn't seem to belong here since the method suggests its just getting people.
             * Also is there any particular reason for adding either Bob or Betty randomly? P.S the upper range input for random.Next() is exclusive not inclusive
             */
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                    /*
                     * Comment:
                     * DateTime has a AddYears() method, which would be simplier and also handle leap years. P.S you made a typo for number of days used.
                     */
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                    /*
                     * Comment:
                     * Exception is a bit broad, IndexOutOfBoundsException would probably be better suited.
                     */
                }
            }
            return _people;
            /*
             * Comment:
             * I assume you don't want anything outside this class mutating this list since its a private field, you might want to return a readonly or immutable list instead.
             */
        }

        /*
         * Comment:
         * It would probably be worth updating this method to retrive people for a input name rather than hard coding it for a single name.
         * Unless it is a very simple terany operator where a third condition would never be added, I opt to just use a if condition because it makes it easier to read and understand quickly.
         */
        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            /*
             * Comment:
             * I would add a method returning the person's age to the people class, that way you don't have to calculate it for comparisons every time.
             */
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }
        
        /*
         * Comment:
         * Is it just an assumption that people with the same last name are married? I don't think it caters for scenarios where multiple people have the same last name.
         * Also curious as to why it truncates the last name if its longer than 255 characters. Also suggest renaming the method name to be a bit more specific.
         */
        public string GetMarried(People p, string lastName)
        {
            /*
             * Comment:
             * It's good practice to use braces following if conditions, even if it contains one line of code. It just reduces that chance of an unintentional bug if someone inserts a new line of code.
             */
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255)
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}