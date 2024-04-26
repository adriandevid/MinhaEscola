'use client';

import { FaConnectdevelop } from "react-icons/fa";
import { useContext, useEffect, useState } from "react";
import { CgLogOut } from "react-icons/cg";
import Menu from "../components/_ui/menu";
import Dash from "../components/pages/Home";
import { Router } from "../components/pages/Router";
import { AplicationContext } from "@/contexts/appContext";
import { signIn, signOut, useSession } from "next-auth/react";

export default function Home() {
  const [routerSelected, setRouterSelected] = useState<any>();
  const [loadingPage, setLoadingPage] = useState<boolean>(false);
  const [isOpen, isOpenMenu] = useState<boolean>(true);

  const { data: session, status } : any = useSession();
  

  const {
    getPaths,
    getRouters,
    formatResponses,
    getSchema,
    apiDatas
  } = useContext(AplicationContext);

  useEffect(function () {
    if(status == "unauthenticated") {
      signIn("identity-server4", undefined, { prompt: "login" });
    }
  }, [status])

  return (
    <div className="flex h-full w-full relative">
      <div className={
        (isOpen ? "bg-gray-400/[.2] h-full flex justify-between flex-col" :
        "bg-gray-400/[.2] h-full flex justify-between flex-col hidden")
      }>
        <div className="overscroll-x-none overflow-x-hidden h-[50rem] max-h-[60rem] max-h-[60rem]:overflow-scroll">
          <div className="h-[5rem] w-full flex justify-center items-center flex-col">
            <p className="font-[700] flex items-center"><FaConnectdevelop color="green" /> API BOOK</p>
            <p className="text-[12px] text-green-600">Api documentation automatic</p>
          </div>
          {/* <div className="pb-5 pt-5 flex justify-center">
            <div className="flex items-center border-b-[1px] border-b-black/[.2] gap-2">
              <FaSearch />
              <input className="bg-transparent focus:outline-none" placeholder="search" />
            </div>
          </div> */}
          <div className="w-[20rem] pt-5">
            {
              apiDatas != undefined ?
              <ul className="flex flex-col">
                {
                  getPaths().map((item: string, index: number) => {
                    return (
                      <li key={index}><Menu title={item} onClick={(router, method) => {
                        var value = {
                          router,
                          method,
                          path: item
                        }
                        setRouterSelected({
                          ...value
                        })
                      }}></Menu> </li>
                    )
                  })
                }
              </ul> :
              <div className="animate-pulse flex space-x-4">
                <div className="flex-1 space-y-6 py-1 p-5">
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                  <div className="h-5 bg-slate-700 rounded"></div>
                </div>
              </div>
            }
            
          </div>
        </div>
        {
          session == undefined ?
            <div className="p-4 text-sm/6">
              <p><strong>Profile:</strong>{session?.user?.role}</p>
              <p><strong>User: </strong>{session?.user?.email}</p>
              <button className="p-2 bg-green-700 text-white rounded-lg w-full mt-4 shadow-md text-sm/6 font-bold flex justify-center items-center" onClick={async () => {
                await signIn("identity-server4", { redirect: true, callbackUrl: "http://host.docker.internal:3000/" });
              }}><CgLogOut size={20} /> Login</button>
            </div>
          :
          <div className="p-4 text-sm/6">
            <p><strong>Profile:</strong>{session?.user?.role}</p>
            <p><strong>User: </strong>{session?.user?.email}</p>
            <button className="p-2 bg-green-700 text-white rounded-lg w-full mt-4 shadow-md text-sm/6 font-bold flex justify-center items-center" onClick={async () => {
              await signOut({ redirect: true, callbackUrl: "http://host.docker.internal:3001/" });
            }}><CgLogOut size={20} /> Sair</button>
          </div>
        }
      </div>
      {
        loadingPage?
        <div className=" absolute bg-gray-400/[.5] w-full h-full z-[100] flex flex-col justify-center items-center">
        <div className="flex flex-col justify-center items-center">
          <div className="relative">
            <div className="spin-rotate absolute"><FaConnectdevelop color="green" size={100} /></div> 
            <div className="spin-rotate-return asbolute"><FaConnectdevelop color="green" size={100} /></div>
          </div>
          <p className="mt-2 font-bold">Loading...</p>
        </div>
        </div> : <></>
      }
      {
        routerSelected == undefined ?
        <Dash isOpenMenu={isOpen} setStateMenu={(state: boolean) => { isOpenMenu(state); }} /> :
        <Router router={routerSelected.router} method={routerSelected.method} path={routerSelected.path} />
      }
    </div>
  );
}