// <copyright file="OrderProduct.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>


namespace Domain
{
    /// <summary>
    /// Запись блюда в заказе.
    /// </summary>
    public class ListItem : IEquatable<ListItem>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ListItem"/>.
        /// </summary>
        /// <param name="quantity"> Количество. </param>
        /// <param name="order"> Заказ. </param>
        public ListItem(int quantity, Order order)
        {
           if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

           this.Id = Guid.NewGuid();
           this.Quantity = quantity;
            this.Order = order ?? throw new ArgumentNullException(nameof(order));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Количество позиций одного блюда.
        /// </summary>
        public int Quantity { get; protected set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Блюда.
        /// </summary>
        public ISet<Product> Products { get; set; } = new HashSet<Product>();

        /// <summary>
        /// Добавление блюда в запись для заказа.
        /// </summary>
        /// <param name="product"> Блюдо. </param>
        public void AddProductToListItem(Product product)
        {
            this.Products.Add(product);
            product.ListItem = this;
        }

        /// <inheritdoc/>
        public bool Equals(ListItem? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}
