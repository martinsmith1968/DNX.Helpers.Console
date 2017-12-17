namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class ConsoleTextItem.
    /// </summary>
    public class ConsoleTextItem
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public ConsoleTextItemType Type { get; private set; }

        /// <summary>
        /// Gets the ident.
        /// </summary>
        /// <value>The ident.</value>
        public string Ident { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleTextItem" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="ident">The ident.</param>
        private ConsoleTextItem(ConsoleTextItemType type, string ident)
        {
            Type  = type;
            Ident = ident;
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ConsoleTextItem.</returns>
        public static ConsoleTextItem Create(ConsoleTextItemType type)
        {
            return Create(type, null);
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="ident">The ident.</param>
        /// <returns>DNX.Helpers.Console.Text.ConsoleTextItem.</returns>
        public static ConsoleTextItem Create(ConsoleTextItemType type, string ident)
        {
            var instance = new ConsoleTextItem(type, ident);

            return instance;
        }
    }
}
