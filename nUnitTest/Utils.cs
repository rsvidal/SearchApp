namespace nUnitTest
{
    internal class Utils
    {
        public const string DIRECTORY = @"C:/search_test/";
        public const string WRONG_DIRECTORY = @"C:/wrong_directory/";

        public const string NAME1 = "1.txt";
        public const string NAME2 = "2.txt";
        public const string NAME3 = "3.txt";
        public const string NAME4 = "image.jpg";
        public const string FILENAME1 = DIRECTORY + NAME1;
        public const string FILENAME2 = DIRECTORY + NAME2;
        public const string FILENAME3 = DIRECTORY + NAME3;
        public const string FILENAME4 = DIRECTORY + NAME4;
        public const string WRONG_FILENAME = @"C:/wrong_directory/not_exists.txt";

        public static readonly string[] CONTENT1 = { "This is the content into a file.", "These sentences are used in a test.", "'is' word appears twice in this file" };
        public static readonly string[] CONTENT2 = { "Hello, world!" };

        public static readonly string[] WORDS = { "This", "is", "the", "content", "into", "a", "file", "These", "sentences", "are", "used", "in", "a", "test", "is", "word", "appears", "twice", "in", "this", "file" };
        public const string WORD = "is";

        public const string READ_DIRECTORY_METHOD = "ReadDirectory";
    }
}
