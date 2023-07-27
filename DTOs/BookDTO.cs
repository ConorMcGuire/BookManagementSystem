namespace BookManagementSystem.DTOs
{
    public class BookDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; } 
        //We can just send the author name as a string instead of an object or the author id as these  would make nos sense to the user.
    }

}
