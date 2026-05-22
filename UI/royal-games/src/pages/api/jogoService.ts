import { Asul } from "next/font/google";
import {api} from "./api";

type jogoFormulario ={
    nome: string,
    descricao: string,
    preco: string,
    classificacaoId: number,
    image: File | null,
    generosId: number[],
    plataformaId: number[],
}

interface jogoListagem {
    nome: string,
    descricao: string,
    preco: string,
    dataLancamento: Date,
    classificacaoId: number,
    imagemUrl: string,
    generosId: number[],
    plataformaId: number[],
    statusJogo: boolean
}

export async function listarJogo(){
    try{
        const response = await api.get("Jogo");

        const jogosAtivos = response.data.filter((jogo: jogoListagem) => jogo.statusJogo === true);

        const jogos = jogosAtivos.map((jogo: jogoListagem) => ({
            ...jogo,
            imagemUrl: `${api.defaults.baseURL}${jogo.imagemUrl}`
        }));

        return jogos

    } catch(error: any){
        throw new Error(error.response.data);
    }
}

export async function listarPorId (id: number){
    try{
        const response = await api.get("Jogo/" + id);

        const jogo = {
            ...response.data,
            imagemUrl: `${api.defaults.baseURL}${response.data.imagemUrl}`
        };

        return jogo
    }catch(error: any){
        throw new Error(error.response.data);
    }
}

export async function cadastrarJogo(dados: jogoFormulario){
    try{
        const formData = new FormData();

        formData.append("Nome", dados.nome);
        formData.append("Descricao", dados.descricao);
        formData.append("Preco", dados.preco);

        formData.append("ClassificacaoId", String(dados.classificacaoId));
        
        if(dados.image)
            formData.append("Imagem", dados.image);

        dados.generosId.forEach((id) => {
            formData.append("GenerosId", id.toString());
        });
        dados.plataformaId.forEach((id) => {
            formData.append("PlataformaId", id.toString());
        });
        
        await api.post("Jogo", formData);
    } catch(error:any){
        throw new Error(error.response.data)
    }
}

export async function editarJogo(jogoId: number, dados: jogoFormulario){
    try{
        const formData = new FormData();

        formData.append("Nome", dados.nome);
        formData.append("Descricao", dados.descricao);
        formData.append("Preco", dados.preco);
        
        formData.append("ClassificacaoId", String(dados.classificacaoId));

        if(dados.image)
            formData.append("Imagem", dados.image);
        dados.generosId.forEach((id) => {
            formData.append("GenerosId", id.toString());
        });
        dados.plataformaId.forEach((id) => {
            formData.append("PlataformaId", id.toString());
        });

        await api.put("Jogo/" + jogoId, formData)
    } catch(error: any){
        throw new Error(error.response.data)
    }
}

export async function excluirJogo(jogoId: number){
    try{
        await api.delete("Jogo/" + jogoId);
    }
    catch(error: any){
        throw new Error(error.response.data);
    }
}