'use client';

import { AplicationContext } from "@/contexts/appContext";
import { useContext, useEffect } from "react";
import { FaBars, FaConnectdevelop } from "react-icons/fa"
import { IoClose } from "react-icons/io5";

export default function Dash({ isOpenMenu, setStateMenu }: { isOpenMenu: boolean, setStateMenu: (state: boolean) => void }) {
  const {
    getPaths,
    getRouters,
    formatResponses,
    getSchema,
    apiDatas
  } = useContext(AplicationContext);

  return (
    apiDatas != undefined ?
    <div className="p-10  w-full z-0">
      <div className=" md:hidden z-0 pb-2">
        {
          isOpenMenu ?
            <button className="text-black-400 border-solid border-[1px] p-2" onClick={() => { setStateMenu(false) }}><IoClose size={20} /></button> :
            <button className="text-black-400 border-solid border-[1px] p-2" onClick={() => { setStateMenu(true) }}><FaBars size={20} /></button>
        }
      </div>
      <div className="pb-4">
        <p className="text-sm/6">school - <span className="font-[700]">api/v1/school</span></p>
      </div>
      <div className="flex flex-col">
        <div><div className="spin-rotate"><FaConnectdevelop color="green" size={50} /></div> </div>
        <p className="font-[700] text-[3rem]">{apiDatas.info.title}</p>
        <p className="font-semibold">Wellcome to API Documentation of MinhaEscola.Service</p>
        <a href="http://localhost:7005/swagger/v1/swagger.json" className="text-sm/6 text-blue-400">Download Documentation in OpenApi Pattern</a>
        <a href="#" className="text-sm/6 text-blue-400">Download Documentation of model</a>
        <a href="http://localhost:7005/" className="text-sm/6 text-blue-400">Server: http://localhost:7005</a>
        <p className="text-sm/6">Version: <strong>{apiDatas.info.version}</strong></p>
        <p className="text-sm/6">Openapi Version: <strong>{apiDatas.openapi}</strong></p>
      </div>
      <div className="flex gap-10">
        <div className="pt-10">
          <p className="font-[700]">Authentication Scheme</p>
          <ul className="text-[14px] pt-2">
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">JWT - Json Web Token</li>
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">Intropection Pattern</li>
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">OAUTH Authorization</li>
          </ul>
        </div>

        <div className="pt-10">
          <p className="font-[700]">Tecnologies of system</p>
          <ul className="text-[14px] pt-2">
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">C#</li>
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">DOTNET CORE - 6.0</li>
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">OPENIDDICT</li>
            <li className="before:content-[' '] before:w-[2px] before:h-[80%] before:bg-green-400 before:absolute before:left-0 after:content-[' '] after:w-[10px] after:h-[2px] after:bg-green-400 after:absolute after:left-0 after:bottom-[20%] relative pl-4">IDENTITY</li>
          </ul>
        </div>
      </div>
      <div>

      </div>
    </div> : <></>
  )
}