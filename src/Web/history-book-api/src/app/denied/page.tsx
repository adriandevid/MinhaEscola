"use client";

import { signIn } from "next-auth/react";
import { FaConnectdevelop } from "react-icons/fa";

export default function Page() {
    return (
        <section className="bg-white">
            <div className="pl-[1.5rem] pr-[1.5rem] pt-[4rem] pb-[4rem] ml-[auto] mr-[auto] max-w-[1280px]">
                <div className="text-center ml-[auto] mr-[auto] max-w-[640px] flex flex-col justify-center items-center">
                    <div className="spin-rotate"><FaConnectdevelop color="green" size={100} /></div>
                    <h1 className="font-[800] text-[1.5rem] leading-[2rem] mb-[2rem] text-primary-600 dark:text-primary-500">401 Unauthorized</h1>
                    <p className="font-[700] text-[2.25rem] leading-[2.5rem] text-[#111827] mb-[1rem] tracking-[-0.025em]">Whoops! You not have access.</p>
                    <p className="mb-[1rem] text-[#6b7280]">Log in to the application to perform actions:</p>
                    <button className="pl-[2rem] pr-[2rem] pt-[0.5rem] pb-[0.5rem] bg-green-600/[.9] hover:bg-green-700/[.9]  text-white rounded-[10px] shadow-md" onClick={async () => { await signIn("identity-server4",  { redirect: true, callbackUrl: "/" }, { prompt: "login" }) }}>Login</button>
                </div>
            </div>
        </section>
    )
}