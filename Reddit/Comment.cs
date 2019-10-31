/*
 * Name: Brett Carney ZID: z1860518
 * Partner: Adedayo Uwensuyi ZID: z1703101
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reddit
{
    public class Comment : IComparable
    {
        public readonly uint id;
        public readonly uint authorID;
        private string content;
        public readonly uint parentID;
        public readonly uint upVotes;
        public readonly uint downVotes;
        public readonly DateTime timeStamp;
        public SortedSet<Comment> commentReplies;
        private readonly string[] filteredWords = { "fudge", "shoot", "baddie", "butthead" };

        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Comment()
        {
            id = 0;
            authorID = 0;
            content = "";
            upVotes = 0;
            downVotes = 0;
            timeStamp = DateTime.Now;
            commentReplies = new SortedSet<Comment>();
        }

        /// <summary>
        ///     Generate a Comment using all fields
        /// </summary>
        /// <param name="id">Comment ID</param>
        /// <param name="authorID">Author ID</param>
        /// <param name="content">Content ID</param>
        /// <param name="parentID">Parent ID</param>
        /// <param name="upVotes">Comment Up Votes</param>
        /// <param name="downVotes">Comment Down Votes</param>
        /// <param name="timeStamp">Comment Timestamp</param>
        public Comment(uint id, uint authorID, string content, uint parentID, uint upVotes,
            uint downVotes, DateTime timeStamp)
        {
            this.id = id;
            this.authorID = authorID;
            this.content = content;
            this.parentID = parentID;
            this.upVotes = upVotes;
            this.downVotes = downVotes;
            this.timeStamp = timeStamp;
            commentReplies = new SortedSet<Comment>();
        }

        /// <summary>
        ///     Generate a Comment using content, authorID, and parentID
        /// </summary>
        /// <param name="content">Comment Content</param>
        /// <param name="authorID">Author ID</param>
        /// <param name="parentID">Parent ID</param>
        public Comment(string content, uint authorID, uint parentID)
        {
            Random rand = new Random();
            id = Convert.ToUInt32(rand.Next(9999));
            this.parentID = parentID;
            Content = content;
            upVotes = 1;
            downVotes = 0;
            this.authorID = authorID;
            commentReplies = new SortedSet<Comment>();
            timeStamp = DateTime.Now;
        }

        /// <summary>
        ///     Property for the comment score
        /// </summary>
        public uint Score
        {
            get => upVotes - downVotes;
            set { }
        }

        /// <summary>
        ///     Property for getting and setting content text
        /// </summary>
        public string Content
        {
            get => content;
            set
            {
                if (value.Length < 1 || value.Length > 1000)
                    return;
                //Check all filtered words using linq
                if (filteredWords.Any(value.Contains))
                    throw new FoulLanguageException(value);
                content = value;
            }
        }

        /// <summary>
        ///     Compares two Comment Objects
        /// </summary>
        /// <param name="obj">Comment Object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Comment otherScore = obj as Comment;
            if (otherScore != null)
                return Score.CompareTo(otherScore.Score);
            throw new ArgumentException("Object is not a Comment");
        }

        // Collection of Person objects. This class
        // implements IEnumerable so that it can be used
        // with ForEach syntax.
        public class Comments : IEnumerable
        {
            private readonly Comments[]  _comments;

            public Comments(Comments[] commentArray)
            {
                 _comments = new Comments[commentArray.Length];

                for (var i = 0; i < commentArray.Length; i++)  _comments[i] = commentArray[i];
            }

            // Implementation for the GetEnumerator method.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public CommentEnum GetEnumerator()
            {
                return new CommentEnum( _comments);
            }
        }

        // When you implement IEnumerable, you must also implement IEnumerator.
        public class CommentEnum : IEnumerator
        {
            public Comments[]  _comments;

            // Enumerators are positioned before the first element
            // until the first MoveNext() call.
            private int position = -1;

            public CommentEnum(Comments[] list)
            {
                 _comments = list;
            }

            public Comments Current
            {
                get
                {
                    try
                    {
                        return  _comments[position];
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
                return position <  _comments.Length;
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current => Current;
        }
    }
}