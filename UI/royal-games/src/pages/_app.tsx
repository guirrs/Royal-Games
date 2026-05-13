import "@/styles/globals.css";
import type { AppProps } from "next/app";
import { Orbitron, Exo_2 } from "next/font/google";

const orbitron = Orbitron({
  variable: "--font-orbitron",
  weight: ["400", "500", "600", "700"],
  subsets: ["latin"],
});

const exo_2 = Exo_2({
  variable: "--font-exo_2",
  weight: ["400", "500", "600", "700"],
  subsets: ["latin"],
})

export default function App({ Component, pageProps }: AppProps) {
  return(
    <main className={`${orbitron.variable} ${exo_2.variable}`}>
      <Component {...pageProps} />
    </main>
  )
}
