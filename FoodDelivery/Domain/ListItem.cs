// <copyright file="OrderProduct.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>


namespace Domain
{
    /// <summary>
    /// Продукты в заказе.
    /// </summary>
    public class ListItem : IEquatable<ListItem>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ListItem"/>.
        /// </summary>
        /// <param name="quantity"> Количество. </param>
        public ListItem(int quantity)
        {
           if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

           this.Id = Guid.NewGuid();
           this.Quantity = quantity;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Количество позиций одного блюда.
        /// </summary>
        public int Quantity { get; protected set; }

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
