import styles from "./lista-jogos.module.css"
import CardJogo from "../card-jogo/card-jogo"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faAngleLeft, faAngleRight, faArrowLeft, faArrowRight } from "@fortawesome/free-solid-svg-icons"

const ListaJogos = () => {
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
                <CardJogo />
                <CardJogo />
                <CardJogo />
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