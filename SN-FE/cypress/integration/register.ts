import { util } from 'utils/util';

describe('Register User', () => {

    it("should fill register form and redirect to login page", () => {
  
      cy.visit(util.URLFE+'/registar jogador');

      cy.get('[id="nome"]').type("Hugo");
      cy.get('[id="email"]').type("hugo@gmail.com");
      cy.get('[id="password"]').type("123456");
      cy.get('[id="dataNascimento"]').type("10/08/2001");
      cy.get('[id="numeroTelefone"]').type("912342423");
      cy.get('[id="estadoHumor"]').select("proud");
      cy.get('[id="URLFacebook"]').type("testefb");
      cy.get('[id="URLLinkedIn"]').type("testelinkedin");
      cy.get('[id="listaTags"]').type("teste");
      cy.get('[id="cidade"]').type("chaves");
      cy.get('[id="pais"]').type("Portugal");
      cy.get('.button_others').contains('Termos').click();
  
      // Locate and submit the form
      cy.get('.button').contains('Registar').click();
  
      cy.location("pathname", {timeout: 10000}).should("eq", "/login");
      //cy.wait();
  
    })
  
  })