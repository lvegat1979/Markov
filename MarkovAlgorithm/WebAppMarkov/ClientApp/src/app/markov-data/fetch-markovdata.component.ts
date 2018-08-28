import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
//import { $ } from 'protractor';
declare var $: any;

@Component({
  selector: 'app-markovfetch-data',
  templateUrl: './fetch-markovdata.component.html'
})
export class FetchMarkovDataComponent {
  public markovresult: MarkovResult[];
  public words: Words[];
  public letters: Letters[];
  public findOcurrencies: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<MarkovResult[]>(baseUrl + 'api/MarKovData/MarkovResult').subscribe(result => {
      this.markovresult = result;
    }, error => console.error(error));

    http.get<Words[]>(baseUrl + 'api/MarKovData/WordsPuzzle').subscribe(result => {
      this.words = result;
    }, error => console.error(error));


    this.findOcurrencies = (wordToFind) => {

      const params = new HttpParams()
        .set('word', wordToFind);


      http.get<Letters[]>(baseUrl + 'api/MarKovData/WordsPuzzleByWord', { params: params }).subscribe(result => {
        this.letters = result;
        result.forEach((a:any, b:any) => {

          var sel = "#markovTable > tr:nth-child(" + parseInt(a.row + 1) + ") > td:nth-child(" + parseInt(a.column + 1) + ")";
          var color = $(sel).css("background-color");
          if (color && color == "rgb(255, 255, 0)")
            $(sel).css("background-color", "white");
          else
              $(sel).css("background-color", "yellow");
          
        });

      }, error => console.error(error));
    }

  }

  getSelecteditem() {
    //this.radioSel = this.words.find(Item => Item.value === this.radioSelected);
    //this.radioSelectedString = JSON.stringify(this.radioSel);
  }

  onItemChange(item) {
    this.getSelecteditem();
  }

  toggleVisibility(e, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    var isMarked = this.words.find(Item => Item.marked === true);

    this.findOcurrencies(e.currentTarget.id);

  }

}

interface MarkovResult {
  row: number;
  col: number;
  character: string;
}

interface Words {
  name: string;
  value: string;
  marked: boolean;

}

interface Letters {
  name: string;
  x: number;
  y: number;

}
