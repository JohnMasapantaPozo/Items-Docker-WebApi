/*  Record Types: Classes to support data models.
        Useful for immutable objects.
        Hold expressions supports.
        Value-based equality support to allow compare instances of the class.

    * Init in properties allows its value to be definied only during object creation.
*/

using System;

namespace WebApiDEMO
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}