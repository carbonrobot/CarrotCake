namespace CarrotCake.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Domain;

    public class InventoryService
    {
        private readonly IDataContextFactory _dataContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="factory">The <see cref="IDataContextFactory"/>.</param>
        public InventoryService(IDataContextFactory factory)
        {
            _dataContextFactory = factory;
        }

        /// <summary>
        /// Gets a list of all inventory items
        /// </summary>
        /// <returns>IEnumerable&lt;InventoryItem&gt;.</returns>
        public IEnumerable<InventoryItem> List()
        {
            using (var context = _dataContextFactory.Create())
            {
                return context.List<InventoryItem>().ToList();
            }
        }
    }
}