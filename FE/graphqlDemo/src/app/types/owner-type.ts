import { AccountType } from "./account-type";

export type OwnerType = {
    'id': string;
    'name': string;
    'address': string;
    'accounts': AccountType[];
}