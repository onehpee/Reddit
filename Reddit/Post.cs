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
    ///     Represents a post on a Subreddit
    /// </summary>
    public class Post : IComparable
    {
        public readonly uint authorID;
        public readonly uint id;
        public readonly uint subHome;
        public readonly DateTime timeStamp;
        public uint downVotes;
        public SortedSet<Comment> postComments;
        public string postContent;
        public string title;
        public uint upVotes;
        public uint weight;
        public bool isLocked;
        private readonly string[] filteredWords = { "fudge", "shoot", "baddie", "butthead" };

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Post()
        {
            id = 0;
            title = "";
            authorID = 0;
            postContent = "";
            subHome = 0;
            upVotes = 0;
            downVotes = 0;
            weight = 0;
            timeStamp = DateTime.Now;
            isLocked = false;
            postComments = new SortedSet<Comment>();
        }

        /// <summary>
        ///     Constructor for all fields
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <param name="title">Post Title</param>
        /// <param name="authorID">Post Author ID</param>
        /// <param name="postContent">Post Content</param>
        /// <param name="subHome">Post Subreddit ID</param>
        /// <param name="upVotes">Post Up Votes</param>
        /// <param name="downVotes">Post Down Votes</param>
        /// <param name="weight">Post Weight</param>
        /// <param name="timeStamp">Post Timestamp</param>
        /// <param name="isLocked">Locked Status</param>
        public Post(uint isLocked, uint id, string title, uint authorID, string postContent, uint subHome, uint upVotes,
            uint downVotes, uint weight, DateTime timeStamp)
        {
            this.id = id;
            this.authorID = authorID;
            this.subHome = subHome;
            this.upVotes = upVotes;
            this.downVotes = downVotes;
            this.weight = weight;
            this.timeStamp = timeStamp;
            Title = title;
            PostContent = postContent;
            postComments = new SortedSet<Comment>();
            this.isLocked = Convert.ToBoolean(isLocked);
        }

        /// <summary>
        ///     Constructor for creating new posts
        /// </summary>
        /// <param name="title">Post Title</param>
        /// <param name="authorID">Post Author ID</param>
        /// <param name="postContent">Post Content</param>
        /// <param name="subHome">Post Subreddit ID</param>
        public Post(string title, uint authorID, string postContent, uint subHome)
        {
            Random rand = new Random();
            id = Convert.ToUInt32(rand.Next(9999));
            this.title = title;
            this.authorID = authorID;
            this.postContent = postContent;
            this.subHome = subHome;
            upVotes = 1;
            downVotes = 0;
            timeStamp = DateTime.Now;
            postComments = new SortedSet<Comment>();
        }

        /// <summary>
        ///     Property for Title
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (value.Length > 1 && value.Length < 100)
                    // Check all filtered words using linq
                    if (filteredWords.Any(value.Contains))
                        throw new FoulLanguageException(value);
                    else
                        title = value;
                else
                    title = value.Substring(0, 99);

            }
        }

        /// <summary>
        ///     Property for PostContent
        /// </summary>
        public string PostContent
        {
            get => postContent;
            set
            {
                if (value.Length > 1 && value.Length < 1000)
                    // Check all filtered words using linq
                    if (filteredWords.Any(value.Contains))
                        throw new FoulLanguageException(value);
                    else
                        postContent = value;
            }
        }

        /// <summary>
        ///     Difference in Up Votes and Down Votes represents
        ///     the Score property
        /// </summary>
        public int Score => (int) (upVotes - downVotes);

        /// <summary>
        ///     Post rating property
        /// </summary>
        public double PostRating
        {
            get
            {
                if (weight == 0)
                    return Score;
                if (weight == 1)
                    return .66 * Score;
                if (weight >= 2)
                    return 0;
                return 0;
            }
        }

        /// <summary>
        ///     Compares this Post to another Post based on rating
        /// </summary>
        /// <param name="obj">Post Object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherPost = obj as Post;
            if (otherPost != null)
                return PostRating.CompareTo(otherPost.PostRating);
            throw new ArgumentException("Object is not a Post");
        }

        /// <summary>
        ///     Collection of Post objects. This class
        ///     implements IEnumerable so that it can be used with ForEach syntax.
        /// </summary>
        public class Posts : IEnumerable
        {
            private readonly Post[] _posts;

            public Posts(Post[] postArray)
            {
                _posts = new Post[postArray.Length];

                for (var i = 0; i < postArray.Length; i++) _posts[i] = postArray[i];
            }

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public PostEnum GetEnumerator()
            {
                return new PostEnum(_posts);
            }
        }

        /// <summary>
        ///     Enumerator for Posts
        /// </summary>
        public class PostEnum : IEnumerator
        {
            public Post[] _posts;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            private int position = -1;

            public PostEnum(Post[] list)
            {
                _posts = list;
            }

            public Post Current
            {
                get
                {
                    try
                    {
                        return _posts[position];
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
                return position < _posts.Length;
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current => Current;
        }

        public override string ToString()
        {
            var result = new StringBuilder($"<{upVotes}/{downVotes}> {Title}: {PostContent}");
            return result.ToString();
        }
    }
}