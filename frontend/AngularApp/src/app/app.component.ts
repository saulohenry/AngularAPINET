import { Component } from '@angular/core';
import { ApiService } from './services/api.services'

import { Notas } from './Models/Notas';
import { HistoricoAprovacao } from './Models/HistoricoAprovacao';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'AngularApp';

  
  constructor(private _ApiService: ApiService)
  {}


  lstNotas: Notas[];

  idusuario: number = 1;
  dataemissao = new Date('2020-06-30T00:00:00');

  ngOnInit()
  {
    this._ApiService.getNotas(this.idusuario, this.dataemissao)
    .subscribe
    (
      data =>
      {
        this.lstNotas = data;
      }
    );
  }

  public Acao(event, nota: Notas)
  {
    var ha = new HistoricoAprovacao();
    ha.IdNota = nota.Id;
    ha.Operacao = "Visto";
    ha.Usuario = this.idusuario.toString();
    ha.DataOcorrencia = new Date();

    this._ApiService.post(ha);

  }

}
