export interface Product {
    id: number,
    name?: string,
    description: string,
    ageRestriction: number,
    company: string,
    price: number,
    image: File
}