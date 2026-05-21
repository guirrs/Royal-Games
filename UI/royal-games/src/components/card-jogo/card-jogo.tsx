import Link from "next/link";
import styles from "./card-jogo.module.css"
import { formatarPreco } from "@/utils/formatar";

type Jogo = {
    jogoID: number,
    nome: string,
    preco: number,
    image: string,
    paginaJogo: boolean,
    onDelete: (jogoId: number) => void
}

const CardJogo = ({ jogoID, nome, preco, image, onDelete, paginaJogo }: Jogo) => {

    return (
        <article id={styles.card}>
            <Link href={"/detalhe-jogo/" + jogoID}>
                <img src={image} alt="" />
            </Link>
            <h3>{nome}</h3>
            <h4>{formatarPreco(preco)}</h4>
            {paginaJogo ? (
                <>
                    <button onClick={() => onDelete(jogoID)}>Excluir</button>
                    <button>Editar</button>
                </>
            ) : (
                <Link href={"/detalhe-jogo/" + jogoID}>
                    <button>Detalhes</button>
                </Link>
            )}
        </article>
    )
}

export default CardJogo;