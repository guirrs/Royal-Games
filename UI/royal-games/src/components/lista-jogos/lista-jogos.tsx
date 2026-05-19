import styles from "./lista-jogos.module.css"
import CardJogo from "../card-jogo/card-jogo"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import Jogo from "@/pages/jogo"
import { faAngleLeft, faAngleRight} from "@fortawesome/free-solid-svg-icons"
import { listarJogo } from "@/pages/api/jogoService"
import { useEffect, useState } from "react"

interface Jogo {
    jogoID: number,
    nome: string,
    preco: number,
    imagemUrl: string,
    statusjogo: boolean
}

const ListaJogos = () => {

    const [jogos, setJogos] =  useState<Jogo[]>([]);

    async function listar() {
        try{
            const lista = await listarJogo();
            setJogos(lista);
        }catch(error: any){
            console.log(error.message)
        }
    }

    useEffect(() =>{
        listar()
    }, [])

    return (
        <div id={styles.container}>
            <h2>Catálogo de jogos</h2>
            <hr></hr>
            <div id={styles.filtros}>
                <input type="text" placeholder="Pesquisar..." />
                <button>Menor Preço</button>
                <button>Categoria</button>
            </div>
            <div id={styles.jogos}>
                {jogos.length > 0 ? jogos.map((item) =>(
                    <CardJogo
                    key={item.jogoID}
                    jogoID={item.jogoID}
                    nome={item.nome}
                    image={item.imagemUrl}
                    preco={item.preco}
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