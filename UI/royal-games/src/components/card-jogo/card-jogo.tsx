import Link from "next/link";
import styles from "./card-jogo.module.css"
import { formatarPreco } from "@/utils/formatar";

type Jogo ={
    jogoID: number,
    nome: string,
    preco: number,
    image: string,
}

const CardJogo = ({jogoID, nome, preco, image} : Jogo) =>{
    
    return(
        <article id={styles.card}>
            <Link href={"/detalhe-jogo/" + jogoID}>
                <img src={image} alt="" />
            </Link>
            <h3>{nome}</h3>
            <h4>{preco}</h4>
            <Link href={"/detalhe-jogo/" + jogoID}>
                <button>Destalhes</button>
            </Link>
        </article>
    )
}

export default CardJogo;