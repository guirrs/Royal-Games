import {api} from "./api";

export async function listarGenero(){
    try{
        const response = await api.get("Genero");
        return response;
    }catch(error: any){
        throw new Error(error.response.data);
    }
}