import { util } from 'utils/util';

describe('Login User', () => {

    it("should fill login form and redirect to dashboard", () => {
  
      cy.visit(util.URLFE+'/login');

      cy.get('[id="email"]').type("hugo@gmail.com");
      cy.get('[id="password"]').type("123456");
  
      // Locate and submit the form
      cy.get('[type="submit"]').contains('Login').click();
  
      cy.location("pathname", {timeout: 10000}).should("eq", "/dashboard");
      //cy.wait();
  
    })
  
  })