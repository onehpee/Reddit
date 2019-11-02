/*
 * Name: Brett Carney ZID: z1860518
 * Partner: Adedayo Uwensuyi ZID: z1703101
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Reddit
{
    public class User : IComparable
    {
        private readonly int _commentScore;
        public readonly uint Id;
        private readonly List<string> _moderatingSubs;
        public readonly string _name;
        public readonly int _postScore;
        public readonly uint _userType;
        private enum Classification
        {
            User = 0,
            Moderator = 1,
            Admin = 2
        }

        /// <summary>
        ///     Default Constructor that takes no arguments and sets all values to zero
        /// </summary>
        public User()
        {
            Id = 0;
            _name = "";
            _postScore = 0;
            _commentScore = 0;
            _userType = 0;
            Password = "";
            _moderatingSubs = new List<string>();
        }

        /// <summary>
        ///     Alternate constructor to provide initial values to all attributes
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="name">User Name</param>
        /// <param name="postScore">Post Score</param>
        /// <param name="commentScore">Comment Score</param>
        /// <param name="userType">Type of user</param>
        /// <param name="password">User Password</param>
        /// <param name="moderatingSubs">Subs user is a moderator in</param>
        public User(uint id, string name, int postScore, int commentScore, uint userType, string password,
            List<string> moderatingSubs)
        {
            this.Id = id;
            this._name = name;
            this._postScore = postScore;
            this._commentScore = commentScore;
            this._userType = userType;
            Password = password;
            this._moderatingSubs = moderatingSubs;
        }

        /// <summary>
        ///     Alternate constructor for when we want new users
        /// </summary>
        /// <param name="name">User Name</param>
        public User(string name)
        {
            Id = 0;
            this._name = name;
            _postScore = 0;
            _commentScore = 0;
            _userType = 0;
            _moderatingSubs = new List<string>();
        }


        /// <summary>
        ///     Name must contain at least 5 chars and no more that 21
        ///     can't begin or end with space
        /// </summary>
        public string Name
        {
            get
            {
                if (_name.Length < 3 || _name.Length <= 21)

                    return _name;
                return _name;
            }

            set
            {
                if (_name.StartsWith(" ")) return;


                if (_name.EndsWith(" "))

                    return;
            }
        }

        /// <summary>
        ///     Creating Password Hashes
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        ///     The sum of both Post/Comment Score.
        /// </summary>
        public int TotalScore
        {
            get { return TotalScore = _postScore + _commentScore; }


            set { }
        }

        /// <summary>
        ///     Sort by name in ascending order
        /// </summary>
        /// <param name="obj">User Object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherUser = obj as User;
            if (otherUser != null)
                return _name.CompareTo(otherUser._name);
            throw new ArgumentException("Object is not a Temperature");
        }

        /// <summary>
        ///     Override
        /// </summary>
        /// <returns>String Version of User</returns>
        public override string ToString()
        {
            string classifier = "\t\t";

            if (_userType == 1)
                classifier = "\t(M)\t";
            if (_userType == 2)
                classifier = "\t(A)\t";

            var result = new StringBuilder($"{Name}{classifier}({_postScore}/{_commentScore})");
            return result.ToString();
        }
    }
}