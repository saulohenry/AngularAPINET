import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient , HttpParams } from '@angular/common/http';

import { HistoricoAprovacao } from './Models/HistoricoAprovacao';

@Injectable()
export class ApiService
{
    constructor(private http: HttpClient){}

    getNotas(idusuario: number, data: Date): Observable<any>
    {
        let params = new HttpParams();
        params = params.append('idusuario', idusuario.toString());
        params = params.append('data', data.toString())
        return this.http.get("http://localhost:63403/api/notas", {params: params});
    }

    post(ha:HistoricoAprovacao): Observable<any>
    {
        return this.http.post("http://localhost:63403/api/Historico", ha)
    }
}