/*
 * Name: Brett Carney ZID: z1860518
 * Partner: Adedayo Uwensuyi ZID: z1703101
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reddit
{
    /// <summary>
    ///     Represents a Subreddit
    /// </summary>
    internal class Subreddit : IComparable
    {
        public readonly uint id;
        public uint active;
        public uint members;
        private string name;
        public SortedSet<Post> subPosts;

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Subreddit()
        {
            id = 0;
            name = "";
            members = 0;
            active = 0;
            subPosts = new SortedSet<Post>();
        }

        /// <summary>
        ///     Generate a subreddit based on a name.
        /// </summary>
        /// <param name="name">Represents the subreddit name</param>
        public Subreddit(string name)
        {
            id = 0;
            Name = name;
            members = 0;
            active = 0;
            subPosts = new SortedSet<Post>();
        }

        /// <summary>
        ///     Generate a subreddit based on id, name, members, and active members
        /// </summary>
        /// <param name="id">Subreddit ID</param>
        /// <param name="name">Subreddit Name</param>
        /// <param name="members">Subreddit Member Count</param>
        /// <param name="active">Subreddit Active Member Count</param>
        public Subreddit(uint id, string name, uint members, uint active)
        {
            this.id = id;
            Name = name;
            this.members = members;
            this.active = active;
            subPosts = new SortedSet<Post>();
        }

        /// <summary>
        ///     Represents the Name of a Subreddit
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if ((value.Length >= 3 && value.Length <= 21) && (value.First() != ' ' && value.Last() != ' '))
                    name = value;
                else
                    name = " ";
            }
        }

        /// <summary>
        ///     Compares this Subreddit to another Subreddit based on name
        /// </summary>
        /// <param name="obj">Subreddit Object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherSubreddit = obj as Subreddit;
            if (otherSubreddit != null)
                return name.CompareTo(otherSubreddit.name);
            throw new ArgumentException("Object is not a Subreddit");
        }

        /// <summary>
        ///     Collection of Subreddit objects. This class
        ///     implements IEnumerable so that it can be used with ForEach syntax.
        /// </summary>
        public class Subreddits : IEnumerable
        {
            private readonly Subreddit[] _subreddits;

            public Subreddits(Subreddit[] subredditArray)
            {
                _subreddits = new Subreddit[subredditArray.Length];

                for (var i = 0; i < subredditArray.Length; i++) _subreddits[i] = subredditArray[i];
            }

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public SubEnum GetEnumerator()
            {
                return new SubEnum(_subreddits);
            }
        }

        /// <summary>
        ///     Enumerator for Subreddits
        /// </summary>
        public class SubEnum : IEnumerator
        {
            public Subreddit[] _subreddits;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            private int position = -1;

            public SubEnum(Subreddit[] list)
            {
                _subreddits = list;
            }

            public Subreddit Current
            {
                get
                {
                    try
                    {
                        return _subreddits[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return position < _subreddits.Length;
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current => Current;
        }

        /// <summary>
        ///     Override
        /// </summary>
        /// <returns>String Version of Subreddit</returns>
        public override string ToString()
        {
            var result = new StringBuilder($"{Name}");
            return result.ToString();
        }
    }
}