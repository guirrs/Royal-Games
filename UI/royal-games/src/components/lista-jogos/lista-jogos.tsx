import styles from "./lista-jogos.module.css"
import CardJogo from "../card-jogo/card-jogo"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import Jogo from "@/pages/jogo"
import { faAngleLeft, faAngleRight} from "@fortawesome/free-solid-svg-icons"
import { excluirJogo, listarJogo } from "@/pages/api/jogoService"
import { useEffect, useState } from "react"
import { erro, notificacao, toastConfirmarExclusao } from "@/utils/toast"
import { verificarAutenticacao } from "@/utils/auth"

interface Jogo {
    jogoId: number,
    nome: string,
    preco: number,
    imagemUrl: string,
    statusjogo: boolean
}

interface ListaJogosProps {
    cadastro: boolean;
}


const ListaJogos = ({cadastro} :ListaJogosProps) => {

    const [jogos, setJogos] =  useState<Jogo[]>([]);

    const [ordem, setOrdem] = useState("todos");

    const [pesquisa, setPesquisa] = useState("");

    const[ estaAutenticado, setEstaAutenticado] = useState(false);

    async function listar() {
        try{
            const lista = await listarJogo();
            setJogos(lista);
        }catch(error: any){
            console.log(error.message)
        }
    }

    function confirmarExclusao(jogoId: number){
        toastConfirmarExclusao( async () => {
            try{
                await excluirJogo(jogoId);

                setJogos((listaAtual) => 
                    listaAtual.map((jogo) => 
                    jogo.jogoId === jogoId
                ? {...jogo, statusJogo: false}
                : jogo)
                )
                notificacao("Produto Inativo!")
                listar()
            }catch(error: any){
                erro(error.message)
            }
        })
    }

    useEffect(() =>{
        setEstaAutenticado(verificarAutenticacao());
        listar()
    }, [])

    const jogosFiltrados = jogos.filter((jogo) => 
    jogo.nome.toLowerCase().includes(pesquisa.toLowerCase()))
    .sort((a,b) => {
        if(ordem === "menor_valor"){
            return a.preco - b.preco
        } 
        else if(ordem === "maior_valor"){
            return b.preco - a.preco
        }
        return a.jogoId - b.jogoId
    })

    return (
        <div id={styles.container}>
            <h2>Catálogo de jogos</h2>
            <hr></hr>
            <div id={styles.filtros}>
                <input type="text" placeholder="Pesquisar..." value={pesquisa} onChange={(e) => {setPesquisa(e.target.value)}} />
                <select value={ordem} onChange={(e) => setOrdem(e.target.value)}>
                    <option value="todos">Todos os produtos</option>
                    <option value="menor_valor">Menor valor</option>
                    <option value="maior_valor">Maior valor</option>
                </select>
                <button>Categoria</button>
            </div>
            <div id={styles.jogos}>
                {jogosFiltrados.length > 0 ? jogosFiltrados.map((item) =>(
                    <CardJogo
                    key={item.jogoId}
                    jogoID={item.jogoId}
                    nome={item.nome}
                    image={item.imagemUrl}
                    preco={item.preco}
                    paginaJogo={cadastro}
                    onDelete={confirmarExclusao}
                    />

                )) : (
                    <p>Carregando produto</p>
                )}
            </div>
            <div id={styles.trocaEl}>
                <FontAwesomeIcon icon={faAngleLeft} className={`${styles.botaoTroca} ${styles.seta}`} />
                <button className={styles.botaoTroca}>1</button>
                <button className={styles.botaoTroca}>2</button>
                <button className={styles.botaoTroca}>3</button>
                <button className={styles.botaoTroca}>4</button>
                <button className={styles.botaoTroca}>5</button>
                <FontAwesomeIcon icon={faAngleRight} className={`${styles.botaoTroca} ${styles.seta}`} />
            </div>
        </div>
    )
}

export default ListaJogos