import { api } from "./api";

export function ListarClassificacao(){
    try{
        const response = api.get("Classificacao")
        return response
    }catch(erro: any){
        throw new Error(erro.response.data);
    }
}