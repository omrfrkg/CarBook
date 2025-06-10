﻿namespace CarBook.Dto.ReservationDtos
{
    public class CreateReservationDto
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int CarId { get; set; }
        public int Age { get; set; }
        public int DriverLicenceYear { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
