import { useState, useEffect } from "react";

export function Input({ defaultValue, disabled, propertie, onChange, fatherPropertieName } : { defaultValue: string, propertie?: undefined | string, disabled?: boolean | undefined, onChange?: undefined | ((value: any, propertie?: string, fatherPropertieName?: string | undefined) => void), fatherPropertieName?: string | undefined }) {
    const [click, onClick] = useState<boolean>(false);
    const [valueInput, setValue] = useState<string>(defaultValue);
  
    useEffect(function () {
      setValue(defaultValue);
    }, [propertie]);
  
    useEffect(function () {
      document.body.addEventListener('click', function (e: any) {
        if(!(Array.from(e.target!.classList).filter((item) => item == "input-edit").length > 0)) {
          onClick(false);
        }
      })
    }, []);
  
    return (
      <div className="z-10">
        {
          disabled == false || disabled == undefined ?
          !click ?
          <span className="text-green-400" onClick={() => { 
            onClick(true) 
          }}>&quot;{valueInput}&quot;</span> :
          <input className="text-black input-edit" placeholder="defaultValue" value={valueInput} defaultValue={valueInput} onChange={(e) => { 
            setValue(e.target.value);
  
            if(onChange != undefined) {
              onChange(e.target.value, propertie, fatherPropertieName);
            }
          }} /> : 
          <span className="text-green-400">&quot;{valueInput}&quot;</span>
        }
        <input name={propertie} id={propertie} value={valueInput} hidden></input>
      </div>
    )
  }