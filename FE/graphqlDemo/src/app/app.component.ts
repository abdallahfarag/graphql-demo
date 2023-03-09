import { Component, OnInit } from '@angular/core';
import { GraphqlService } from './services/graphql.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private service: GraphqlService) { }

  ngOnInit(): void {
    //this.service.getOwners();

    //this.service.getOwner('e6a61f15-e921-45fd-9659-a3185451eb54');

    // const ownerToCreate = {
    //   name: 'new name from angular',
    //   address: 'new address from angular'
    // }
    // this.service.createOwner(ownerToCreate);

    // const ownerToUpdate = {
    //   name: 'updated name from angular',
    //   address: 'updated address from angular'
    // }
    // this.service.updateOwner(ownerToUpdate, 'f104ae2b-56af-42bf-bcc6-7d6005191879');

    //this.service.deleteOwner('f104ae2b-56af-42bf-bcc6-7d6005191879');
  }
  title = 'graphqlDemo';
}
