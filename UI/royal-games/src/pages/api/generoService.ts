import { Asul } from "next/font/google";
import {api} from "./api";

export async function listarCategoria(){
    try{
        const response = await api.get("Genero");
        return response;
    }catch(error: any){
        throw new Error(error.response.data);
    }
}