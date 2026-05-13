import styles from "./card-jogo.module.css"

const CardJogo = () =>{
    return(
        <article id={styles.card}>
            <img src="../imgs/jogo.png" alt="" />
            <h3>Titulo</h3>
            <h4>R$ 70,00</h4>
            <button>Destalhes</button>
        </article>
    )
}

export default CardJogo;