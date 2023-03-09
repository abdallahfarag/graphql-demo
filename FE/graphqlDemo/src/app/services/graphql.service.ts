import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { HttpLink } from 'apollo-angular-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';
import { OwnerInputType } from '../types/owner-input-type';
import { OwnerType } from '../types/owner-type';

@Injectable({
  providedIn: 'root'
})
export class GraphqlService {

  public owners: OwnerType[] | undefined;
  public owner: OwnerType | undefined;
  public createdOwner: OwnerType | undefined;
  public updatedOwner: OwnerType | undefined;

  constructor(private apollo: Apollo) {
  }

  public getOwners = () => {
    this.apollo.query({
      query: gql`query getOwners{
      owners{
        id,
        name,
        address,
        accounts{
          id,
          description,
          type
        }
      }
    }`
    }).subscribe(result => {
      this.owners = result.data as OwnerType[];
      console.log(this.owners);
    })
  }

  public getOwner = (id: any) => {
    this.apollo.query({
      query: gql`query getOwner($ownerID: ID!){
      owner(ownerId: $ownerID){
        id,
        name,
        address,
        accounts{
          id,
          description,
          type
        }
      }
    }`,
      variables: { ownerID: id }
    }).subscribe(result => {
      this.owner = result.data as OwnerType;
      console.log(this.owner);
    })
  }

  public createOwner = (ownerToCreate: OwnerInputType) => {
    this.apollo.mutate({
      mutation: gql`mutation($owner: ownerInput!){
        createOwner(owner: $owner){
          id,
          name,
          address
        }
      }`,
      variables: { owner: ownerToCreate }
    }).subscribe(result => {
      this.createdOwner = result.data as OwnerType;
      console.log(this.createdOwner)
    })
  }

  public updateOwner = (ownerToUpdate: OwnerInputType, id: string) => {
    this.apollo.mutate({
      mutation: gql`mutation($owner: ownerInput!, $ownerId: ID!){
        updateOwner(owner: $owner, ownerId: $ownerId){
          id,
          name,
          address
        }
      }`,
      variables: { owner: ownerToUpdate, ownerId: id }
    }).subscribe(result => {
      this.updatedOwner = result.data as OwnerType;
    })
  }

  public deleteOwner = (id: string) => {
    this.apollo.mutate({
      mutation: gql`mutation($ownerId: ID!){
        deleteOwner(ownerId: $ownerId)
       }`,
      variables: { ownerId: id }
    }).subscribe(res => {
      console.log(res.data);
    })
  }
}
