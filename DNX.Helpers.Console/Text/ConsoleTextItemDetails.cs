namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class ConsoleTextItem.
    /// </summary>
    public class ConsoleTextItemDetails
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public ConsoleTextItemType Type { get; private set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Identifier { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleTextItemDetails" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="identifier">The identifier.</param>
        private ConsoleTextItemDetails(ConsoleTextItemType type, string identifier)
        {
            Type       = type;
            Identifier = identifier;
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ConsoleTextItem.</returns>
        public static ConsoleTextItemDetails Create(ConsoleTextItemType type)
        {
            return Create(type, null);
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="identifier">The identifier.</param>
        /// <returns>DNX.Helpers.Console.Text.ConsoleTextItem.</returns>
        public static ConsoleTextItemDetails Create(ConsoleTextItemType type, string identifier)
        {
            var instance = new ConsoleTextItemDetails(type, identifier);

            return instance;
        }
    }
}
