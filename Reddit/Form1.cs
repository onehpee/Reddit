using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Reddit
{
    public partial class Form1 : Form
    {
        private static SortedSet<Subreddit> _subreddits;
        private static SortedSet<User> _users;
        private static Subreddit _selectedSubreddit;
        private static Post _selectedPost;
        private static uint _selectedCommentId;
        private static User _selectedUser;
        private static User _authenticatedUser;
        private static SortedSet<Post> _collectivePosts;

        public Form1()
        {
            InitializeComponent();

            // Initialize our members
            _subreddits = new SortedSet<Subreddit>();
            _users = new SortedSet<User>();
            _selectedSubreddit = new Subreddit();
            _selectedPost = new Post();
            _authenticatedUser = new User();
            _selectedCommentId = 0;

            // Initial Population of Subreddits
            using (var inFile = new StreamReader("subreddits.txt"))
            {
                var subredditRead = inFile.ReadLine(); // Priming read
                while (subredditRead != null)
                {
                    var subredditInfo = subredditRead.Split('\t');
                    var subreddit = new Subreddit(Convert.ToUInt32(subredditInfo[0]), subredditInfo[1],
                        Convert.ToUInt32(subredditInfo[2]), Convert.ToUInt32(subredditInfo[3]));

                    _subreddits.Add(subreddit);

                    subredditRead = inFile.ReadLine();
                }
            }

            // Initial Population of Users
            using (var inFile = new StreamReader("users.txt"))
            {
                var userRead = inFile.ReadLine(); // Priming read
                while (userRead != null)
                {
                    var userInfo = userRead.Split('\t');

                    // Use Linq to find the moderating subs if any
                    var moderatingSubs = userInfo.Where((t, i) => i >= 6).ToList();

                    var user = new User(Convert.ToUInt32(userInfo[0]), userInfo[2], Convert.ToInt32(userInfo[4]),
                        Convert.ToInt32(userInfo[5]), Convert.ToUInt32(userInfo[1]), userInfo[3], moderatingSubs);

                    _users.Add(user);

                    userRead = inFile.ReadLine();
                }
            }

            // Initial Population of Posts
            using (var inFile = new StreamReader("posts.txt"))
            {
                var postRead = inFile.ReadLine(); // Priming read
                while (postRead != null)
                {
                    var postInfo = postRead.Split('\t');
                    var post = new Post(Convert.ToUInt32(postInfo[0]), Convert.ToUInt32(postInfo[1]), postInfo[3],
                        Convert.ToUInt32(postInfo[2]), postInfo[4], Convert.ToUInt32(postInfo[5]),
                        Convert.ToUInt32(postInfo[6]), Convert.ToUInt32(postInfo[7]), Convert.ToUInt32(postInfo[8]),
                        new DateTime(Convert.ToInt32(postInfo[9]), Convert.ToInt32(postInfo[10]),
                            Convert.ToInt32(postInfo[10]), Convert.ToInt32(postInfo[11]),
                            Convert.ToInt32(postInfo[12]),
                            Convert.ToInt32(postInfo[13])));

                    // Look for a subreddit id that matches and add the post
                    foreach (var subreddit in _subreddits.Where(subreddit => subreddit.id == post.subHome))
                        subreddit.subPosts.Add(post);

                    postRead = inFile.ReadLine();
                }
            }

            // Initial Population of Comments
            using (var inFile = new StreamReader("comments.txt"))
            {
                var commentRead = inFile.ReadLine(); // Priming read
                while (commentRead != null)
                {
                    var commentInfo = commentRead.Split('\t');
                    var comment = new Comment(Convert.ToUInt32(commentInfo[0]), Convert.ToUInt32(commentInfo[1]),
                        commentInfo[2], Convert.ToUInt32(commentInfo[3]), Convert.ToUInt32(commentInfo[4]),
                        Convert.ToUInt32(commentInfo[5]),
                        new DateTime(Convert.ToInt32(commentInfo[6]), Convert.ToInt32(commentInfo[7]),
                            Convert.ToInt32(commentInfo[8]), Convert.ToInt32(commentInfo[9]),
                            Convert.ToInt32(commentInfo[10]),
                            Convert.ToInt32(commentInfo[11])));

                    foreach (var subreddit in _subreddits)
                        foreach (var post in subreddit.subPosts)
                            if (post.id == comment.parentID)
                                post.postComments.Add(comment);
                            else
                                foreach (var postComment in post.postComments)
                                    SearchAndAddComment(postComment, comment);
                    commentRead = inFile.ReadLine();
                }
            }

            // Set Data Sources
            Subreddits_Combo_Box.DataSource = _subreddits.ToList();
        }

        /// <summary>
        ///     Recursive helper function to add comments
        /// </summary>
        /// <param name="parent">Parent comment</param>
        /// <param name="commentToAdd">Comment to be added to parent</param>
        /// <returns></returns>
        private static bool SearchAndAddComment(Comment parent, Comment commentToAdd)
        {
            // Base case
            if (parent.id == commentToAdd.parentID)
            {
                parent.commentReplies.Add(commentToAdd);
                return true;
            }

            // When there's still replies

            if (parent.commentReplies.Count > 0)
                foreach (var currentComment in parent.commentReplies)
                    return SearchAndAddComment(parent.commentReplies.First(), commentToAdd);

            return false;
        }

        private static bool SearchAndRemoveComment(Comment parent, Comment commentToRemove, SortedSet<Comment> priorSet)
        {
            // Base case
            if (parent.id == commentToRemove.id)
            {
                priorSet.Remove(commentToRemove);
                //parent.commentReplies.Remove(commentToRemove);
                return true;
            }

            // When there's still replies

            if (parent.commentReplies.Count > 0)
                foreach (var currentComment in parent.commentReplies)
                    return SearchAndRemoveComment(parent.commentReplies.First(), commentToRemove, parent.commentReplies);

            return false;
        }

        private static Comment SearchAndReturnComment(Comment parent, uint commentId)
        {
            // Base case
            if (parent.id == commentId) return parent;

            // When there's still replies
            if (parent.commentReplies.Count > 0)
                foreach (var currentComment in parent.commentReplies)
                    return SearchAndReturnComment(parent.commentReplies.First(), commentId);

            return null;
        }

        private static bool SearchAndEditComment(Comment parent, Comment commentToEdit, string newComment)
        {
            // Base case
            if (parent.id == commentToEdit.id)
            {
                parent.Content = newComment;
                return true;
            }

            // When there's still replies
            if (parent.commentReplies.Count > 0)
                foreach (var currentComment in parent.commentReplies)
                    return SearchAndEditComment(parent.commentReplies.First(), commentToEdit, newComment);

            return false;
        }

        private void Search_Text_Box_Enter(object sender, EventArgs e)
        {
            if (Search_Text_Box.Text == "Search Reddit")
            {
                Search_Text_Box.Text = "";
            }
        }

        private void Search_Text_Box_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search_Text_Box.Text))
                Search_Text_Box.Text = "Search Reddit";
        }

        private void Subreddits_Combo_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Represents /r/all if all is selected
            var allPosts = new SortedSet<Post>();

            if (Subreddits_Combo_Box.SelectedItem == null) return;
            if (Subreddits_Combo_Box.SelectedItem.ToString() == "all")
            {
                foreach (var subredditSubPost in _subreddits.SelectMany(subreddit => subreddit.subPosts))
                    allPosts.Add(subredditSubPost);

                // Set this to default since default is our all
                _selectedSubreddit = new Subreddit();

                // Assign our container to the member
                _collectivePosts = allPosts;
            }
            else
            {
                _selectedSubreddit = (Subreddit)Subreddits_Combo_Box.SelectedItem;

                if (_selectedSubreddit != null) _collectivePosts = _selectedSubreddit.subPosts;
            }

            // Remove previous controls and add new ones
            int[] position = { 0, 50 };
            Content_Panel.Controls.Clear();
            foreach (var post in _collectivePosts)
            {
                // Create a new DisplayPost Object
                var currentPostControl = new DisplayPost(post)
                {
                    Location = new Point(position[0], position[1])
                };
                Content_Panel.Controls.Add(currentPostControl);
                position[1] += 250;
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            // TODO When clicked, a new login form opens

            //    protected override void OnLoad(EventArgs e)
            //{
            using (Log_In_Form f2 = new Log_In_Form())
            {
                if (f2.ShowDialog() == DialogResult.OK)
                {
                    foreach (var user in _users)
                    {
                        var _users = new SortedSet<User>();

                        foreach (var name in _users)
                            // Check if right info is entered in login form
                            _users.FirstOrDefault(x => Name  == _selectedUser.Name );
                        if(f2.LogInFormUser != user.Name && f2.LogInFormPass == user.Password)
                        {
                            MessageBox.Show("Wrong Username");
                            f2.ShowDialog();
                        }

                        if(f2.LogInFormUser == user.Name && f2.LogInFormPass != user.Password)
                        {
                            MessageBox.Show("Wrong Password");
                            f2.ShowDialog();
                        }
                            if (f2.LogInFormUser == user.Name && f2.LogInFormPass == user.Password)
                        {
                            Login_Button.Text = $"{f2.LogInFormUser} {user.TotalScore}";
                            _authenticatedUser = _selectedUser;
                        }
                    }
                }
                else
                {
                    f2.Close();
                }
            }
          //  base.OnLoad(e);
        }
    

    private void Search_Text_Box_KeyPress(object sender, KeyPressEventArgs e)
    {
            var allPosts = new SortedSet<Post>();
            // Content_Panel.Controls.Clear();
            if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
                // TODO Search functionality

                foreach (var Filteredset in _subreddits.SelectMany(subreddit => subreddit.subPosts))
                    allPosts.Add(Filteredset);


                // Set this to default since default is our all
                _selectedSubreddit = new Subreddit();

                // Assign our container to the member
                _collectivePosts = allPosts;

                

                Content_Panel.Text = $@"{allPosts}{Environment.NewLine}";

            }
        }

        
    } }