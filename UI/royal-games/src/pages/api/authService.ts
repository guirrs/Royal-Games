import {api} from "./api"
import secureLocalStorage from "react-secure-storage"

export async function login(email: string, senha: string) {
    try{
        const response = await api.post("Autenticacao/login", {email,senha});
        const token = response.data.token;

        console.log(response.data)

        secureLocalStorage.setItem("Token", token)
    }
    catch(error: any){
        console.log(error.data)
        throw new Error("Email ou senha inválidos.");
    }
}