import style from "./footer.module.css"

const Footer = () => {
    return(
        <footer id={style.footer}>
            < img src="../imgs/logo.png" alt="" />
            <div>
                <p>roayalgames@email.com</p>
                <p>(11)99999-9999</p>
                <p>@RoyalGames</p>
            </div>
        </footer>
    )
}

export default Footer