export interface AddressDto {
    street: string;
    houseAndFlatNumber: string;
    city: string;
    postalCode: string
}

export class Address implements AddressDto {
    street: string;
    houseAndFlatNumber: string;
    city: string;
    postalCode: string;

    constructor() {
        this.street = '';
        this.houseAndFlatNumber = '';
        this.city = '';
        this.postalCode = ''
    }
}