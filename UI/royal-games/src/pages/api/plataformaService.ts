import { api } from "./api";

export async function listarPlataforma(){
    try{
        const response = api.get("Plataforma");
        return response;
    }catch(error: any){
        throw new Error(error.response.data);
    }
}