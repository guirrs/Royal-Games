import "@/styles/globals.css";
import { AppProps } from "next/app";
import { Orbitron } from "next/font/google"

const orbitron = Orbitron({
    variable: "--font-padrao",
    weight: ["400", "500", "600", "700"],
    subsets: ["latin"],
});

export default function App({ Component, pageProps }: AppProps) {
    return (
        <Component {...pageProps} />
    )
}